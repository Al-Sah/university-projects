package com.alsah.labwork3;

public class Calculator {

    public static double execute(String number1, String number2, String operation) throws InvalidCalculatorArgument{

        try {
            double n1 = Double.parseDouble(number1);
            double n2 = Double.parseDouble(number2);

            switch (Operation.valueOf(operation)){
                case add:
                    return n1 + n2;
                case divide:
                    return n1 / n2;
                case multiply:
                    return n1 * n2;
                case subtract:
                    return n1 - n2;
            }

        } catch (NumberFormatException e){
            throw new InvalidCalculatorArgument("Failed to parse numbers");
        } catch (IllegalArgumentException e) {
            throw new InvalidCalculatorArgument("Failed to recognize operation");
        }
        return 0;
    }

    private enum Operation{
        multiply,
        divide,
        add,
        subtract
    }
}
