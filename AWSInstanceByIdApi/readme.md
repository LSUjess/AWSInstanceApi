
# Assumptions 
#  1. you already have an AWS profile/account
#  2. Instance will be in the US East (N. Virgina) region -- us-east-1

#  This code was written in Visual Studio 2019 C# using AWS Toolkit for Visual Studio 
#  You need to install and update the toolkit within Visual Studio by using Tools ≫ Extensions ≫ Manage Extensions 
#  You will have to provide AWS profile credentials by adding a new profile inside
#  AWS Explorer or upload a credentials file
# https://docs.aws.amazon.com/toolkit-for-visual-studio/latest/user-guide/credentials.html

# In the project, right click on AWSInstanceByIdApi >> Publish to Elastic Beanstalk.
# https://docs.aws.amazon.com/toolkit-for-visual-studio/latest/user-guide/deployment-beanstalk-traditional.html
# For region, select US East (N. Virgina).

# For example, this instance is the instance running my api
# Mine is http://eubanks2019.us-east-1.elasticbeanstalk.com/api/instanceinfo/i-0c1751b5fc3007049

# To run the API
# Request: url/api/instanceinfo/:instance_id
# Response: { "instancetype": "c3.large", "instancestate": "stopped", "instancename": "nodes.us-east-1a.us.ua.dev" }

