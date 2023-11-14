package com.example.scaner10;

public class ForOrders {
    int _id;
    String _name;
    double _cost;
    double _count;

    // Empty constructor
    public ForOrders(){

    }
    // constructor
    public ForOrders(int id, String name, double cost, double count){
        this._id = id;
        this._name = name;
        this._cost = cost;
        this._count = count;
    }

    // constructor
    public ForOrders(String name, double cost, double count){
        this._name = name;
        this._cost = cost;
        this._count = count;
    }
    public int GetID(){
        return this._id;
    }
    public void SetID(int id){
        this._id = id;
    }
    public String GetName(){
        return this._name;
    }
    public void SetName(String name){
        this._name = name;
    }
    public double GetCost(){
        return this._cost;
    }
    public void SetCost(double cost){
        this._cost = cost;
    }
    public double GetCount(){
        return this._count;
    }
    public void SetCount(double count){
        this._count = count;
    }
}
