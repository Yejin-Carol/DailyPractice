package org;

import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

@Configuration
public class SpringConfig {

	@Bean
	public AA aa() {
		AA a = new AA();
		return a;
	}
}
