package org.alsah;

public enum UnitLevel {
    Minimal,
    Common,
    Advanced,
    Expert{
        @Override
        public UnitLevel next() {
            return this;
        }
    };

    // works as a state machine (Expert - final state)
    public UnitLevel next() {
        return values()[ordinal() + 1];
    }
}
