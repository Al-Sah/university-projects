package org.alsah;

import org.alsah.models.Building;
import org.alsah.models.City;

import java.util.ArrayList;
import java.util.Comparator;
import java.util.Random;
import java.util.Scanner;
import java.util.stream.Collectors;

public class Main {

    public static void main(String[] args) {

        ArrayList<City> cities = setup();

        var cityMax = cities.stream().max(Comparator.comparingInt(o -> o.getBuilding().getNumber()));
        if (cityMax.isPresent()){
            System.out.println("MAX:" + cityMax.get());
        } else {
            System.out.println("City max not found");
        }
        var cityMin = cities.stream().min(Comparator.comparingInt(o -> o.getBuilding().getNumber()));
        if (cityMin.isPresent()){
            System.out.println("MIN:" + cityMin.get());
        } else {
            System.out.println("City min not found");
        }
        System.out.println();

        cities = cities.stream()
                .sorted((o1, o2) -> Integer.compare(o2.getBuilding().getNumber(), o1.getBuilding().getNumber()))
                .collect(Collectors.toCollection(ArrayList::new));

        System.out.println("Sorted");
        cities.forEach(System.out::println);


        Scanner scanner = new Scanner(System.in);
        System.out.println("Enter min even number: ");
        var minEven = scanner.nextInt();
        System.out.println("Enter min even number: ");
        var minOdd = scanner.nextInt();

        for (City city : cities) {
            var tmp = city.getBuilding().getFloors();
            if((tmp % 2 == 0 && tmp > minEven) || (tmp % 2 != 0 && tmp > minOdd)){
                System.out.println(city);
            }
        }
    }

    private static ArrayList<City> setup(){
        Random random = new Random();
        ArrayList<City> cities = new ArrayList<>();

        for (int i = 0; i < random.nextInt(10)+10; i++) {
            cities.add(
                    new City(
                            "street"+i,
                            random.nextInt(1000) + 100,
                            new Building(1 + random.nextInt(100), 1 + random.nextInt(20))
                    )
            );
        }

        cities.forEach(System.out::println);
        System.out.println("             ");

        return cities;
    }
}