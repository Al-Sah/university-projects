package org.alsah.meal;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.ToString;

import java.util.List;
import java.util.Optional;


@ToString
@AllArgsConstructor
public class Lunch {

    @Getter
    private final LunchType type;
    
    @Getter // each lunch must contain main course;
    private final MainCourse mainCourse;

    @Getter
    private final List<Beverage> beverages;

    // Optional
    private final String starter;
    private final String soup;
    private final String salad;
    private final String dessert;


    public Optional<String> getStarter() {
        return Optional.ofNullable(starter);
    }

    public Optional<String> getSoup() {
        return Optional.ofNullable(soup);
    }

    public Optional<String> getSalad() {
        return Optional.ofNullable(salad);
    }

    public Optional<String> getDessert() {
        return Optional.ofNullable(dessert);
    }
}
