package com.yj.org2.conf;

import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

import com.yj.org2.cls.BB;

@Configuration
public class MyConf {

	@Bean
	public BB bb() {
		return new BB();
	}
	
}
