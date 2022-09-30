package org.alsah;

public class ArmyManager {

    public static Squad createSquadOf(final Class<? extends Unit> unitType, final int amount) {
        var squad = new Squad();
        for (int i = 0; i < amount; i++) {
            try {
                squad.add(unitType.getConstructor().newInstance());
            } catch (Exception e) {
                System.out.println("Failed to create unit " + e.getMessage());
            }
        }
        return squad;
    }

    public static void addToSquad(final Squad squad, Class<? extends Unit> unitType, final int amount) {
        for (int i = 0; i < amount; i++) {
            try {
                squad.add(unitType.getConstructor().newInstance());
            } catch (Exception e) {
                System.out.println("Failed to create unit " + e.getMessage());
            }
        }
    }

}
