package org.alsah;

import org.alsah.meal.Beverage;
import org.alsah.meal.Lunch;
import org.alsah.meal.LunchType;
import org.alsah.meal.MainCourse;

import java.util.ArrayList;

public class LunchBuilder implements Builder {

    private static LunchBuilder instance;

    private ArrayList<Beverage> beverages;

    private MainCourse main;
    private LunchType type;
    private String soup;
    private String salad;
    private String dessert;
    private String starter;


    private LunchBuilder(){
        beverages = new ArrayList<>();
        type = LunchType.Custom;
    }

    public static LunchBuilder getInstance() {
        if (instance == null) {
            instance = new LunchBuilder();
        }
        return instance;
    }

    private void Reset(){
        beverages = new ArrayList<>();
        main = null;
        type = LunchType.Custom;
        soup = null;
        salad = null;
        dessert = null;
        starter = null;
    }

    @Override
    public Builder AddBeverage(Beverage beverage) {
        this.beverages.add(beverage);
        return this;
    }

    @Override
    public Builder SetMainCourse(MainCourse mainCourse) {
        this.main = mainCourse;
        return this;
    }

    @Override
    public Builder SetType(LunchType type) {
        this.type = type;
        return this;
    }

    @Override
    public Builder SetStarter(String starter) {
        this.starter = starter;
        return this;
    }

    @Override
    public Builder SetSalad(String salad) {
        this.salad = salad;
        return this;
    }

    @Override
    public Builder SetSoup(String soup) {
        this.soup = soup;
        return this;
    }

    @Override
    public Builder SetDessert(String dessert) {
        this.dessert = dessert;
        return this;
    }

    @Override
    public Lunch getResult() {
        var lunch = new Lunch(type, main, beverages, starter, soup, salad, dessert);
        Reset();
        return lunch;
    }
}