package org.alsah;

import org.alsah.units.*;

public class Main {
    public static void main(String[] args) {

        var army = new Squad();
        var dragon = new Dragon();

        var subGroup = ArmyManager.createSquadOf(Centaur.class, 5);
        ArmyManager.addToSquad(subGroup, Hydra.class, 5);

        army.add(ArmyManager.createSquadOf(Knight.class, 50));
        army.add(ArmyManager.createSquadOf(Elf.class, 25));
        army.add(ArmyManager.createSquadOf(Centaur.class, 3));

        ArmyManager.addToSquad(army, Cyclops.class, 5);
        ArmyManager.addToSquad(army, Orc.class, 75);
        ArmyManager.addToSquad(army, Minotaur.class, 75);
        army.add(dragon);
        army.add(subGroup);
        army.increaseLevel();

        army.print();

        army.remove(dragon);
        System.out.println(army);
        army.clear();
        army.print();
    }
}