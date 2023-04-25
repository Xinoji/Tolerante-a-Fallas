package com.vorozco.model;

public class Tag {
    private Long tagId;
    private Long code;
    private String colorTeam;

    public Tag(Long personId, Long code, String color) {
        this.tagId = personId;
        this.code = code;
        this.colorTeam = color;
    }

    public Long getTagId() {
        return tagId;
    }

    public void setTagId(Long tagId) {
        this.tagId = tagId;
    }

    public Long getCode() {
        return code;
    }

    public void setCode(Long code) {
        this.code = code;
    }

    public String getColorTeam() {
        return colorTeam;
    }

    public void setColorTeam(String colorTeam) {
        this.colorTeam = colorTeam;
    }
}
