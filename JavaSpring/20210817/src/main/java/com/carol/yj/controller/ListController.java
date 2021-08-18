package com.carol.yj.controller;


import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jdbc.datasource.DriverManagerDataSource;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.RequestMapping;

import com.carol.yj.dao.TestDao;
import com.carol.yj.dto.TestDto;

@Controller
public class ListController {

	@Autowired
	TestDao dao = new TestDao();
	
//	@Autowired
//	DriverManagerDataSource dataSource;
//	
	@RequestMapping(value="list")
	public String list(Model model) {
		List<TestDto> rvalue = dao.doList();
		model.addAttribute("a", rvalue); //rvalue는 list.jsp
		

		return "list";
	}
	@RequestMapping(value="insert")
	public String insert(Model model) {
		dao.doInsert();
		return "insert";
	}
	
}