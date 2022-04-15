package com.alsah;

import java.util.*;
import java.util.stream.Collectors;

public class StringParser {

    private final ArrayList<String> words;

    public StringParser(String str){
        words = (ArrayList<String>)
                Arrays.stream(str.strip().split("[ ;:,.()\n-]")) // Parse input
                .distinct()                                            // Remove repeated items
                .filter(s -> !Objects.equals(s, ""))                // Exclude empty string
                .collect(Collectors.toList());
        words.sort(String.CASE_INSENSITIVE_ORDER);
    }

    public ArrayList<String> getWords() {
        return words;
    }

    public Integer getWordsCont() {
        return words.size();
    }

}
