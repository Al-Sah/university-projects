package org.alsah;

public abstract class UnitBasic implements Unit {

    private static final int defaultIncreasement = 25;

    protected UnitLevel level;
    protected String weapon;

    protected final int initialForce;
    protected final int initialHealth;


    public UnitBasic(String weapon){
        this.level = UnitLevel.Minimal;
        this.initialForce = 100;
        this.initialHealth = 100;
        this.weapon = weapon;
    }

    public UnitBasic(int initialForce, int initialHealth, String weapon){
        level = UnitLevel.Minimal;
        this.initialForce = initialForce;
        this.initialHealth = initialHealth;
        this.weapon = weapon;
    }


    @Override
    public UnitLevel getLevel() {
        return level;
    }

    @Override
    public void increaseLevel() {
        level = level.next();
    }

    @Override
    public int getForce() {
        return initialForce + defaultIncreasement * level.ordinal();
    }

    @Override
    public int getHealth() {
        return initialHealth + defaultIncreasement * level.ordinal();
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
        return String.format(
                "%s, %s level\n | weapon: %s\n | force %d\n | health %d",
                this.getClass().getSimpleName(),
                level,
                getWeapon(),
                getForce(),
                getHealth());
    }
}
