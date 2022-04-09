package com.alsah.dao;

import java.util.Map;

public class Utils {

    public static String generateSql(Map<String, Object> filters){

        if(filters.size() == 0) {
            return "";
        }
        var stringBuilder = new StringBuilder(" WHERE ");
        for (Map.Entry<String, Object> entry : filters.entrySet()) {
            stringBuilder.append(entry.getKey()).append(" = ").append(entry.getValue()).append(", ");
        }
        var result = stringBuilder.toString();
        return result.substring(0, result.length()-2);

    }
}
