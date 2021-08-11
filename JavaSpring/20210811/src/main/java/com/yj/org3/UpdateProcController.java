package com.yj.org3;


import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.SQLException;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;

import com.yj.org3.db.DBManager;

@Controller //@Service, @Repository 보통 아무 의미없는 것 Controller라고 많이 씀.
public class UpdateProcController {

	@Autowired
	DBManager dbmd;
	
	@RequestMapping(value="/updateproc", method = RequestMethod.POST)
	public String updateproc(Model model, String para1, String para2) {
		dbmd.updatetest(para1,para2);		
		//dbmd1.updatetest(para2);
		return "updateproc";
		
	}

}
