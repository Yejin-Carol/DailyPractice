package com.carol.yj.dto;

public class TestDto {
	
	private String para1;
	private String para2;
	
	//alt + shift + s -> s
	@Override
	public String toString() {
		return "TestDto [para1=" + para1 + ", para2=" + para2 + "]";
	}

	public String getPara1() {
		return para1;
	}

	public void setPara1(String para1) {
		this.para1 = para1;
	}

	public String getPara2() {
		return para2;
	}

	public void setPara2(String para2) {
		this.para2 = para2;
	}

	
	
}
