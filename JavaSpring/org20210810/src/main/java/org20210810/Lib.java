package org20210810;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;

public class Lib {

	@Autowired
	@Qualifier("aa1")
	AA aa;
	
	@Autowired(required = false) //빈이 없어도 exception 발생하지 않으며 자동 주입 수행하지 않음.
	BB bb; 
	
	public void print() {
		aa.doAA();
	}
	
}
