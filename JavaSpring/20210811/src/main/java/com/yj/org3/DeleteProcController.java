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
public class DeleteProcController {

	@Autowired
	DBManager dbmd;
	
	@RequestMapping(value="/deleteproc", method = RequestMethod.POST)
	public String deleteproc(Model model, String para1) {
		dbmd.deletetest(para1);			
		return "deleteproc";
		
	}

}
