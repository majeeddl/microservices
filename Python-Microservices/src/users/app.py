from flask import Flask,  jsonify,  request


app = Flask(__name__)


@app.route('/',  methods=['GET'])
def orders():
    data = [
        {
            'id': 1,
            'name': 'User 1',
            'description': 'User 1 description'
        },
        {
            'id': 2,
            'name': 'User 2',
            'description': 'User 2 description'
        }]
    return jsonify(data)
