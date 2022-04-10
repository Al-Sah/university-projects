package com.alsah.labwork3.calculator;

import java.io.Serializable;

public class CalculationResult implements Serializable {

    private double number1;
    private double number2;
    private double result;
    private String operation;


    public double getResult() {
        return result;
    }

    public void setResult(double result) {
        this.result = result;
    }

    public CalculationResult() {}

    public double getNumber1() {
        return number1;
    }

    public void setNumber1(double number1) {
        this.number1 = number1;
    }

    public double getNumber2() {
        return number2;
    }

    public void setNumber2(double number2) {
        this.number2 = number2;
    }

    public String getOperation() {
        return operation;
    }

    public void setOperation(String operation) {
        this.operation = operation;
    }
}
