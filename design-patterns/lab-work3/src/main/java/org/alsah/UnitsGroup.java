package org.alsah;

public interface UnitsGroup {

    boolean add(Unit unit);
    boolean add(Unit... units);

    boolean remove(Unit unit);
    boolean remove(Unit... units);
    void clear();
}
