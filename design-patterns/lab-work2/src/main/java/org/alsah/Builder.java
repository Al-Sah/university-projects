package org.alsah;

import org.alsah.meal.Beverage;
import org.alsah.meal.Lunch;
import org.alsah.meal.LunchType;
import org.alsah.meal.MainCourse;

public interface Builder {

    Builder SetMainCourse(MainCourse mainCourse);

    Builder AddBeverage(Beverage beverage);
    Builder SetType(LunchType type);
    Builder SetStarter(String starter);
    Builder SetSalad(String salad);
    Builder SetSoup(String soup);
    Builder SetDessert(String dessert);

    Lunch getResult();
}
