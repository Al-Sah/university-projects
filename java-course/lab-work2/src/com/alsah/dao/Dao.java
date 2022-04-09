package com.alsah.dao;

import java.util.List;
import java.util.Map;
import java.util.Optional;

public interface Dao<T> {

    Optional<T> get(long id);
    List<T> getAll();
    List<T> getAll(Map<String,Object> filter);
    boolean save(T t);
    boolean update(T t);
    boolean delete(T t);
}