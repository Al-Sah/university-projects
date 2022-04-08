package com.alsah;

public class Main {

    public static void main(String[] args) {

        var str = "Java Platform, Standard Edition is a computing platform for development and " +
                "deployment of portable code for desktop and server environments." +
                "Java Standard Edition was formerly known as Java two Platform, Standard Edition. ";

        var stringParser = new StringParser(str);

        System.out.println(" *** RESULT ***");
        System.out.printf("Words in the sentence: %s%n", stringParser.getWordsCont());

        for(String word : stringParser.getWords()){
            System.out.println(word);
        }
    }
}
