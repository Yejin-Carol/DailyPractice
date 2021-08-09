package or20210809;

import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

@Configuration
public class AnnoConf {

	@Bean
	public RM rm() {
		RM rm = new RM(10);
		rm.setRmm(100);
		return rm;
	}
	@Bean
	public JK jk() {
		JK jk = new JK(rm());
		return jk;
	}
}
