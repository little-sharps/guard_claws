version = File.read(File.expand_path("../VERSION", __FILE__)).strip
  
Gem::Specification.new do |spec|
     spec.platform    = Gem::Platform::RUBY
     spec.name        = 'guard_claws'
     spec.version     = version
     spec.files = Dir['guard_claws/bin/Release/*'] + Dir['README.markdown']
     spec.require_path = 'guard_claws/bin/Release/'
     spec.summary     = 'DRY Guard Clauses for c#'
     spec.description = 'Guard_claws provides DRY guard clauses for c# that look like this: Claws.NotNullNotBlank(() => test);'
     spec.authors           = ['Brendan Erwin']
     spec.email             = 'brendanjerwin@gmail.com'
     spec.homepage          = 'http://github.com/littlebits/guard_claws'
end
