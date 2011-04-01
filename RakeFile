require 'rubygems'
require 'albacore'

repo =  $1 if repo.nil? && `git remote show origin` =~ /git@github.com:(.+?)\.git/
repo.chomp!

project = repo.split('/')[1]

tag_name = ENV['TAG']

package_file = "#{project}-#{tag_name}.zip"

def die_from_lack_of_tag ()
	puts "You must provide a TAG=[name]"
	exit 1
end

namespace :release do
	desc "Build release binaries."
	task :build => [:build_35, :build_40]
	
	msbuild :build_40 do |msb|
	  msb.properties :configuration => :Release40
	  msb.targets :Rebuild
	  msb.solution = "#{project}.sln"
	end

	msbuild :build_35 do |msb|
	  msb.properties :configuration => :Release35
	  msb.targets :Rebuild
	  msb.solution = "#{project}.sln"
	end

	desc "Package release image"
	task :package => :build do 
		die_from_lack_of_tag unless tag_name
		
		`NuGet.exe pack guard_claws.nuspec`
	end
	
	desc "Tag repository"
	task :tag do 
		die_from_lack_of_tag unless tag_name 
		File.open('VERSION', 'w') {|f| f.write(tag_name) }
		`git commit VERSION -m"Update version to #{tag_name}."`
		`git tag "#{tag_name}"`
		`git push origin "#{tag_name}"`
	end
		
	desc "Do all release tasks"
	task :all => [:tag, :package] do
	
	end
end