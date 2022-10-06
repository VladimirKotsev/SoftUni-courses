function calculator() {
    
    let a;
    let b;
    let result;

    function call(){

        obj.init('#num1', '#num2', '#result');
    }

    let obj = { 

        init: function(selector1, selector2, resultField) {

            let num1 = document.querySelector(selector1).value;
            let num2 = document.querySelector(selector2).value;
            let res = document.querySelector(resultField);

            a = Number(num1);
            b = Number(num2);
            result = res;
        },
        add: function(){
            call();
            result.value = a + b;
        },
        subtract: function(){
            call();
            result.value = a - b;
        }
        
    };
    
    return obj;
}