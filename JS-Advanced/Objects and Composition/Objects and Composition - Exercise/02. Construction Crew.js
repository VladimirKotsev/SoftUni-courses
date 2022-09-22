function worker(obj){
    if (obj.dizziness === false){
        return obj;
    }

    obj.dizziness = false;
    obj.levelOfHydrated += Number(obj.weight * obj.experience * 0.1);

    return obj;
}

