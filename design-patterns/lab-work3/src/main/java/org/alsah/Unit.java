package org.alsah;

public interface Unit {

    UnitLevel getLevel();
    void increaseLevel();

    // According to the level, values of 'force, 'health' and 'weapon'
    // can be different
    int getForce();
    int getHealth();
    String getWeapon();

    void setSpecialWeapon(String weapon);
}
