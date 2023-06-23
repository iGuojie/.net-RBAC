# .net 实现RBAC动态权限管理
 已经实现WebApi，统一封装返回结果+全局异常处理，EFCore+MySQL
## 认证与授权

认证（Authentication）是指验证用户的身份，通常通过使用用户名和密码进行。只有当用户提供正确的凭据时，他们才被视为已认证。简单来说，认证就是确定你是谁的过程。

授权（Authorization）则是决定已认证用户能做什么的过程。这包括确定用户是否有权限访问特定的资源，或者执行特定的操作。简单来说，授权就是确定你能做什么的过程。

举一个生活中的例子来解释这两个概念。想象一下，你要进入一座高级写字楼。当你到达大楼时，首先需要出示你的身份证或工牌给保安看，这就是认证，保安会通过查看你的证件来确认你的身份。

然后，一旦你的身份得到确认，你可以进入大楼，但这并不意味着你可以随意访问所有的房间。有些房间可能需要特殊权限才能进入，例如你可能需要一个钥匙卡或密码才能进入你的办公室，这就是授权，你只能访问你有权限访问的那些区域。

我采用的方式是jwt认证，jwt中保存用户的角色信息。在授权的时候检查jwt中保存的角色信息，然后查询访问的资源与当前角色是否匹配。

## RBAC

RBAC（Role-Based Access Control，基于角色的访问控制）是一种流行的访问控制策略，它根据用户的角色来分配权限。用户可以被分配一个或多个角色，而每个角色都有自己的一组权限。这样，当用户试图访问某个资源或执行某项操作时，系统会检查用户的角色，然后决定是否允许访问或操作。

RBAC的主要优点是可以将权限管理集中在角色上，而不是单独的用户上，这样可以简化权限管理并提高其效率。例如，如果需要修改某个角色的权限，只需要在一个地方修改，而不需要逐个修改拥有该角色的每个用户的权限。

我们可以用一个生活中的例子来解释RBAC。假设我们在一个公司中，有不同的部门和职位，比如销售部门、财务部门、人事部门，以及职位如经理、员工等。这些部门和职位可以被视为不同的角色。每个角色有其特定的职责和权限。例如，财务部门的人员可能可以访问和修改财务数据，销售部门的人员可以访问和修改销售数据，经理可能可以访问和修改所有部门的数据。

当一个新的员工加入公司时，我们只需要根据他的部门和职位，给他分配相应的角色，他就会自动获得该角色的所有权限。同样，如果一个员工的职位变动，我们只需要更改他的角色，他的权限就会自动更新。这就是RBAC的基本思想。


## 动态权限管理的优劣

动态权限管理，顾名思义，可以在运行时动态地更改权限。例如，你可以在运行时添加、删除或修改角色和权限，你甚至可以将权限直接分配给用户，而不是通过角色。这提供了更大的灵活性，可以更好地适应业务需求的变化。

动态权限管理的优点主要有：

1. 更大的灵活性：你可以在任何时候更改权限，不需要重新部署应用程序。
2. 更好的细粒度控制：你可以对每个用户或每个操作进行更精细的权限控制。
3. 更易于管理：你可以通过用户界面管理权限，而不是通过代码。

动态权限管理的缺点主要有：

1. 实现复杂：动态权限管理通常需要自己实现，这比使用框架提供的权限管理功能要复杂。
2. 性能影响：动态权限管理可能需要在运行时查询数据库或其他数据源，这可能会对性能产生影响。
3. 需要更多的测试：由于权限可以在运行时改变，所以需要更多的测试来确保安全性。


## 完整项目地址

包括 WebApi 统一封装返回结果、全局异常处理、EFCore+MySQL实现权限动态管理

https://github.com/iGuojie/.net-RBAC