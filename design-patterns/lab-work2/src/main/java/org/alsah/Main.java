package org.alsah;

import org.alsah.meal.*;

public class Main {
    public static void main(String[] args) {

        var customLunch = LunchBuilder.getInstance()
                .SetMainCourse(new MainCourse("custom main", MainCourseSize.Big))
                .SetDessert("some dessert")
                .AddBeverage(new Beverage("Cola", BeverageSize.Large, BeverageType.SoftDrink))
                .getResult();

        System.out.println("Created custom lunch: \n" + customLunch);

        var director = new Director(LunchBuilder.getInstance());

        System.out.println("\nFull lunch: \n" + director.getFullLunch());
        System.out.println("\nStandard lunch: \n" + director.getStandardLunch());
        System.out.println("\nLight lunch: \n" + director.getLightLunch());
    }
}