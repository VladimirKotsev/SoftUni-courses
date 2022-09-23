function rectangle(width, height, color){

    color = color[0].toUpperCase() + color.substring(1);
    let obj = {
        width: Number(width),
        height: Number(height),
        color: color,
        calcArea: function() {
            return width * height;
        }
    };

    return obj;

}


