package org.alsah.units;

import org.alsah.UnitBasic;

public class Elf extends UnitBasic {

    public Elf() {
        super(100, 100, "dagger");
    }

    @Override
    public String getWeapon() {
        return switch (level) {
            case Common -> "Glamdring";
            case Advanced -> "Composite bow";
            case Expert -> "Magical power";
            default -> weapon;
        };
    }
}
