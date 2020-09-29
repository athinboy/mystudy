package org.fgq.study.service.feign;

public class FeighResult {

    //region Getter And Setter

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public Integer getAge() {
        return age;
    }

    public void setAge(Integer age) {
        this.age = age;
    }


    // endregion

    private String name;
    private Integer age;


}
