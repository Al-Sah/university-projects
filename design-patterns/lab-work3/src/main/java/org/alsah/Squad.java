package org.alsah;

import java.util.*;

public class Squad implements Unit, UnitsGroup{

    // United units receives additional weapon
    private static final String defaultSquadWeapon = "Fantasy cannon";
    private final ArrayList<Unit> units = new ArrayList<>();

    private UnitLevel level;
    private String weapon;

    public Squad() {
        level = UnitLevel.Minimal;
        weapon = defaultSquadWeapon;
    }

    @Override
    public boolean add(Unit unit) {
        return units.add(unit);
    }

    @Override
    public boolean add(Unit... units) {
        return this.units.addAll(Arrays.asList(units));
    }

    @Override
    public boolean remove(Unit unit) {
        return units.remove(unit);
    }

    @Override
    public boolean remove(Unit... units) {
        return this.units.removeAll(Arrays.asList(units));
    }

    @Override
    public void clear() {
        for (Unit unit : units) {
            if(unit instanceof UnitsGroup){
                ((UnitsGroup) unit).clear();
            }
        }
        units.clear();
    }

    @Override
    public UnitLevel getLevel() {
        return level;
    }

    @Override
    public void increaseLevel() {
        units.forEach(Unit::increaseLevel);
        level = level.next();
    }

    @Override
    public int getForce() {
        return units.stream().mapToInt(Unit::getForce).sum();
    }

    @Override
    public int getHealth() {
        return units.stream().mapToInt(Unit::getHealth).sum();
    }

    @Override
    public String getWeapon() {
        return weapon;
    }

    @Override
    public void setSpecialWeapon(String weapon) {
        this.weapon = weapon;
    }

    @Override
    public String toString() {
        var sb = new StringBuilder();
        getUnitsCountByType(units).forEach((type, count) -> sb.append(
                String.format("Units of '%s' : %d\n ", type, count)
        ));

        return String.format(
                "Squad %s level\n | units totally: %d\n | special weapon: %s\n | force %d\n | health %d\n %s",
                level,
                getUnitsCount(units),
                getWeapon(),
                getForce(),
                getHealth(),
                sb
        );
    }

    private int getUnitsCount(List<Unit> units){
        int accumulator = 0;
        for (Unit unit : units) {
            if(unit instanceof Squad){
                accumulator += getUnitsCount(((Squad) unit).units);
            } else {
                accumulator ++;
            }
        }
        return accumulator;
    }

    private HashMap<String, Integer> getUnitsCountByType(List<Unit> units){
        var counter = new HashMap<String, Integer>();
        for (Unit unit : units) {
            var type = unit.getClass().getSimpleName();
            Integer count = counter.get(type);
            if(count == null){
                counter.put(type, 1);
            } else {
                counter.replace(type, ++count);
            }
        }
        return counter;
    }

    public void print(){
        System.out.println(this);
        units.forEach(unit -> {
            if(unit instanceof Squad){
                ((Squad) unit).print();
            }else {
                System.out.println(unit);
            }
        });
    }
}
