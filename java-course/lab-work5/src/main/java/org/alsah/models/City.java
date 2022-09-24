package org.alsah.models;

import lombok.AllArgsConstructor;
import lombok.Data;

@Data
@AllArgsConstructor
public class City {
    private String street;
    private int peopleCount;
    private Building building;
}
