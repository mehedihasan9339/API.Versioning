## API Versioning

In this scenario, there are two versions available: **version 1 (v1)** and **version 2 (v2)**.

### Version 1 (v1)

![Version 1 Image](https://raw.githubusercontent.com/mehedihasan9339/API.Versioning/master/API.Versioning/images/image%201.png)

When querying data using **v1**, the response includes the following fields:
- `id`
- `achievementName`
- `achievementId`

### Version 2 (v2)

![Version 1 Image](https://raw.githubusercontent.com/mehedihasan9339/API.Versioning/master/API.Versioning/images/image%202.png)

In contrast, querying data using **v2** introduces an additional field named `date`.

### Simultaneous Access

Both API versions can be accessed concurrently by simply adjusting the version name in the route.

### Supported Versions

To identify supported versions, inspect the headers as shown in the following image:

![Version 1 Image](https://raw.githubusercontent.com/mehedihasan9339/API.Versioning/master/API.Versioning/images/image%203.png)
