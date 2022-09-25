package org.alsah;

import org.alsah.meal.*;

public class Director {

    // dependency inversion
    private final Builder builder;
    public Director(Builder builder) {
        this.builder = builder;
    }

    public Lunch getStandardLunch(){
        return builder
                .SetType(LunchType.Standard)
                .SetMainCourse(new MainCourse("standard main", MainCourseSize.Standard))
                .AddBeverage(new Beverage("standard drink", BeverageSize.Standard, BeverageType.SoftDrink))
                .SetSoup("standard soup")
                .SetSalad("standard salad")
                .getResult();
    }

    public Lunch getLightLunch(){
        return builder
                .SetType(LunchType.Light)
                .SetMainCourse(new MainCourse("light main", MainCourseSize.Standard))
                .AddBeverage(new Beverage("drink", BeverageSize.Standard, BeverageType.SoftDrink))
                .getResult();
    }

    public Lunch getFullLunch(){
        return builder
                .SetType(LunchType.Full)
                .SetStarter("tasty starter")
                .SetMainCourse(new MainCourse("standard main", MainCourseSize.Standard))
                .AddBeverage(new Beverage("standard drink", BeverageSize.Standard, BeverageType.SoftDrink))
                .SetSoup("standard soup")
                .SetSalad("standard salad")
                .SetDessert("tasty dessert")
                .getResult();
    }
}
