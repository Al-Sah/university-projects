package com.alsah.labwork3.calculator;

public class Calculator {

    public static CalculationResult execute(String number1, String number2, String operation) throws InvalidCalculatorArgument {

        try {
            CalculationResult result = new CalculationResult();
            result.setNumber1(Double.parseDouble(number1));
            result.setNumber2(Double.parseDouble(number2));
            result.setOperation(operation);
            switch (Operation.valueOf(operation)){
                case add:
                     result.setResult(result.getNumber1() + result.getNumber2());
                    return result;
                case divide:
                    result.setResult(result.getNumber1() / result.getNumber2());
                    return result;
                case multiply:
                    result.setResult(result.getNumber1() * result.getNumber2());
                    return result;
                case subtract:
                    result.setResult(result.getNumber1() - result.getNumber2());
                    return result;
            }
        } catch (NumberFormatException e){
            throw new InvalidCalculatorArgument("Failed to parse numbers");
        } catch (IllegalArgumentException e) {
            throw new InvalidCalculatorArgument("Failed to recognize operation");
        }
        throw new InvalidCalculatorArgument("Something went wrong))");
    }

    private enum Operation{
        multiply,
        divide,
        add,
        subtract
    }
}
