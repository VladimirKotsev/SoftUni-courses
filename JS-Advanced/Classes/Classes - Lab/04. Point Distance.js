class Point{

    constructor(x, y){

        this.x = x;
        this.y = y;
    }

    static distance(p1, p2){

        let dx = p2.x - p1.x;
        let dy = p2.y - p1.y;

        return Math.sqrt(dx ** 2 + dy ** 2);
    }
}
