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
	task :build => [:assemblyinfo, :build_35, :build_40]
	
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
		
		`NuGet.exe pack guard_claws.nuspec Version=#{tag_name}`
	end

    desc "Update Version"
    assemblyinfo :assemblyinfo do |asm|
        die_from_lack_of_tag unless tag_name 
        asm.output_file = "guard_claws/Properties/AssemblyInfo.cs"
        asm.version = "#{tag_name}"
        asm.file_version = asm.version
        asm.title = project
        asm.com_visible = false
        asm.copyright = "Copyright (c) Brendan Erwin (and contributors) 2011"
    end
	
	desc "Tag repository"
	task :tag => :assemblyinfo do 
		die_from_lack_of_tag unless tag_name 
		`git commit guard_claws/Properties/AssemblyInfo.cs -m"Update version to #{tag_name}."`
		`git tag "#{tag_name}"`
		`git push origin "#{tag_name}"`
	end
		
	desc "Do all release tasks"
	task :all => [:tag, :package] do
	
	end
end