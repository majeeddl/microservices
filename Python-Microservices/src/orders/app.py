from flask import Flask,  jsonify,  request


app = Flask(__name__)


@app.route('/',  methods=['GET'])
def orders():
    data = [
        {
            'id': 1,
            'name': 'Order 1',
            'description': 'Order 1 description'
        },
        {
            'id': 2,
            'name': 'Order 2',
            'description': 'Order 2 description'
        }]
    return jsonify(data)
