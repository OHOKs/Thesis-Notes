# Full backend setup (prisma & node)

```bash
npm init -y
```
```bash
npm install --save-dev nodemon
npm install prisma --save-dev
npm install express @prisma/client body-parser dotenv
```
```bash
npx prisma init
```
```bash
npx prisma migrate dev --name initial_migration
```
```bash
npx prisma generate
```
```bash
npx nodemon index.js
```

