import json
from flask_sqlalchemy import SQLAlchemy
from flask import Flask, request
from datetime import datetime, timedelta


app = Flask(__name__)
app.config["SQLALCHEMY_DATABASE_URI"] = "sqlite:///dbb.sqlite3"
app.config["SQLALCHEMY_TRACK_MODIFICATIONS"] = False
db = SQLAlchemy(app)


class User(db.Model):
    id = db.Column(db.Integer, primary_key=True)
    password = db.Column(db.String(50), nullable=False)
    username = db.Column(db.String(50), nullable=False)
    income = db.Column(db.Integer, nullable=False)
    email = db.Column(db.String(50), nullable=False, unique=True)
    balance = db.Column(db.Integer, default=0)
    birthDate = db.Column(db.DateTime, default=datetime.utcnow)
    cards = db.relationship("Card", backref="user", lazy=True)
    transactions = db.relationship("Transaction", backref="user", lazy=True)
    loans = db.relationship("Loan", backref="user", lazy=True)

    def format(self):
        return {
            "id": self.id,
            "password": self.password,
            "username": self.username,
            "income": self.income,
            "balance": self.balance,
            "birthDate": str(self.birthDate),
            "email": self.email,
            "cards": [c.format() for c in self.cards],
            "transactions": [t.format() for t in self.transactions],
            "loans": [l.format() for l in self.loans],
        }


class Loan(db.Model):
    id = db.Column(db.Integer, primary_key=True)
    amount = db.Column(db.Float, nullable=False)
    interest_rate = db.Column(db.Float)
    user_id = db.Column(db.Integer, db.ForeignKey("user.id"), nullable=False)

    def format(self):
        return {
            "id": self.id,
            "amount": self.amount,
            "interest_rate": str(self.interest_rate * 100) + "%",
        }


class Transaction(db.Model):
    __tablename__ = "transaction"
    id = db.Column(db.Integer, primary_key=True)
    amount = db.Column(db.Float, nullable=False)
    date = db.Column(db.DateTime, nullable=False, default=datetime.utcnow)
    status = db.Column(db.Boolean, nullable=False, default=False)
    user_id = db.Column(db.Integer, db.ForeignKey("user.id"), nullable=False)
    transfer_account = db.Column(db.String(50))
    trans_type = db.Column(db.String(50))

    def format(self):
        return {
            "id": self.id,
            "amount": self.amount,
            "date": str(self.date),
            "status": self.status,
            "transfer_account": None
            if not self.transfer_account
            else self.transfer_account,
            "trans_type": None if not self.trans_type else self.trans_type,
        }


class Card(db.Model):
    id = db.Column(db.Integer, primary_key=True)
    issue_date = db.Column(db.DateTime, nullable=False, default=datetime.utcnow)
    end_date = db.Column(
        db.DateTime, nullable=False, default=datetime.now() + timedelta(days=1000)
    )
    ccv = db.Column(db.String(3), nullable=False)
    card_type = db.Column(db.String(50), nullable=False)
    user_id = db.Column(db.Integer, db.ForeignKey("user.id"), nullable=False)

    def format(self):
        return {
            "id": self.id,
            "issue_date": str(self.issue_date),
            "end_date": str(self.end_date),
            "ccv": self.ccv,
            "card_type": self.card_type,
        }


@app.route("/Register", methods=["POST"])
def EnterUserData():
    data = request.get_json()
    user = User()
    user.income = data["income"]
    user.username = data["username"]
    user.password = data["password"]
    user.email = data["email"]
    try:
        db.session.add(user)
        db.session.commit()
        return data

    except:
        return {}


@app.route("/addCard", methods=["POST"])
def addCards():
    data = request.get_json()
    card = Card()
    card.user_id = data["id"]
    card.ccv = data["ccv"]
    card.card_type = data["card_type"]
    db.session.add(card)
    db.session.commit()
    return data


@app.route("/getTransactions", methods=["POST", "GET"])
def getTransaction():
    data = request.get_json()
    idd = data["id"]
    transs = Transaction.query.filter_by(user_id=idd).all()
    return json.dumps({"transactions": [t.format() for t in transs]})


@app.route("/addLoan", methods=["POST"])
def addLoan():
    data = request.get_json()
    loan = Loan()
    loan.user_id = data["id"]
    loan.interest_rate = data["interest_rate"]
    loan.amount = data["amount"]
    db.session.add(loan)
    db.session.commit()
    return data


@app.route("/getLoans", methods=["POST", "GET"])
def getLoans():
    data = request.get_json()
    idd = data["id"]
    loans = Loan.query.filter_by(user_id=idd).all()
    return json.dumps({"loans": [l.format() for l in loans]})


@app.route("/getCards", methods=["POST", "GET"])
def getCards():
    data = request.get_json()
    idd = data["id"]
    cards = Card.query.filter_by(user_id=idd).all()
    return json.dumps({"cards": [c.format() for c in cards]})


@app.route("/getUser", methods=["POST", "GET"])
def getUser():
    data = request.get_json()
    emaill = data["email"]
    pw = data["pw"]
    user = User.query.filter_by(email=emaill).first()

    if not user or user.password != pw:
        return {}

    return user.format()


@app.route("/addTransaction", methods=["POST"])
def addTransfer():
    trans = Transaction()
    data = request.get_json()

    trans.trans_type = data["trans_type"]
    trans.amount = data["amount"]
    trans.user_id = data["id"]

    if data["trans_type"] == "DEPOSIT":
        sender = User.query.filter_by(id=data["id"]).first()
        sender.balance += float(data["amount"])

    if data["trans_type"] == "WITHDRAW":
        sender = User.query.filter_by(id=data["id"]).first()
        if float(data["amount"]) > sender.balance:
            return {}
        sender.balance -= float(data["amount"])

    if data["trans_type"] == "TRANSFER":
        sender = User.query.filter_by(id=data["id"]).first()
        receiver = User.query.filter_by(username=data["transfer_account"]).first()
        if not receiver:
            return {}
        sender.balance -= float((data["amount"]))
        receiver.balance += float(data["amount"])
        trans.transfer_account = data["transfer_account"]

    db.session.add(trans)
    db.session.commit()
    return data


if __name__ == "__main__":
    db.create_all()
    app.run(debug=True)
