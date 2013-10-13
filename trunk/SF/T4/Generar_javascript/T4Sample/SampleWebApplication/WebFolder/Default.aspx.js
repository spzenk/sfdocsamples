function button1_onclick() {
    var text1 = document.getElementById("text1");
    var text2 = document.getElementById("text2");
    var calculator = new Calculator(parseFloat(text1.value), parseFloat(text2.value));
    alert(calculator.Add());
}

function Calculator(op1, op2) {
    this._operator1 = op1;
    this._operator2 = op2;
}

Calculator.prototype.Add = function () {
    debugger;
    return this._operator1 + this._operator2;
}