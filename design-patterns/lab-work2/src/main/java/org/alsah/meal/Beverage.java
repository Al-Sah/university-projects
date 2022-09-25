package org.alsah.meal;


import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.ToString;

@Getter
@ToString
@AllArgsConstructor
public class Beverage {

    private final String name;
    private final BeverageSize size;
    private final BeverageType type;




}
