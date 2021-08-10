package com.yj.org2;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;

import com.yj.org2.cls.AA;
import com.yj.org2.cls.BB;

/**
 * Handles requests for the application home page.
 */
@Controller
public class HomeController {
	
	private static final Logger logger = LoggerFactory.getLogger(HomeController.class);
	
	@Autowired
	AA aa;
	
	@Autowired
	BB bb;
	
//	@RequestMapping(value = "/", method = RequestMethod.GET)
//	public String home(Model model, HttpServletRequest req) {
	
	//String number = (String) req.getParameter("bb");
	//bb.setAa(Integer.parseInt(number));//평균화시켜 숫자화시킴
//	System.out.println("aa.getAa() = "+aa.getAa());
//	model.addAtrribute("bb",bb);
//	return "home";
//	}
	
	@RequestMapping(value = "/bb", method = RequestMethod.GET)
	public String bb(Model model, int cc) {
		System.out.println("cc= " +cc);
		System.out.println("bb.getAa() = "+bb.getAa());
		model.addAttribute("bb", bb);//8장에서 확인 가능 ("속성명", 속성값)
		return "bb"; //bb.jsp로 가세요.
	}

}
