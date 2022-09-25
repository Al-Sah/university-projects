package org.alsah.meal;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.ToString;

@Getter
@ToString
@AllArgsConstructor
public class MainCourse {

    private final String name;
    private final MainCourseSize size;
}
