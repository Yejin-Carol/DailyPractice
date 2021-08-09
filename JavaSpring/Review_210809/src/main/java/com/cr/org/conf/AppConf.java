package com.cr.org.conf;


import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

import com.cr.org.cls.JJ;

@Configuration
public class AppConf {

	@Bean
	public JJ jj() {
		return new JJ();
	}
}
