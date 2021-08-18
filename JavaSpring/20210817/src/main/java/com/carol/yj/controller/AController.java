package com.carol.yj.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;

import com.carol.yj.DBM;

@Controller
public class AController {

	@Autowired
	DBM dbm; //
	
	@RequestMapping(value = "/a")
	public String a() {
		System.out.println("A a");
		dbm.doA();
		return "a";
	}
	
}
