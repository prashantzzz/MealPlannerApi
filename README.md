# **Recipe and Meal Planning Management System**

## **Project Overview**  
A web-based application that helps users plan meals, create recipes, track nutrition, and manage shopping lists. Features include user authentication, role-based access control (RBAC), recipe management, meal planning, and analytics.

---

## **Tech Stack**
- **Backend:** .NET 8 (C#)  
- **Frontend:** Angular 17+  
- **Database:** SQL Server 2022  
- **Authentication:** JWT  

---

## **Features**
1. **User Authentication & RBAC**  
   - Secure login for Admin, Chef, Nutritionist, Customer, and Meal Planner.  
   - Role-specific permissions.  

2. **Recipe Management**  
   - Create, update, and manage recipes with categories and dietary preferences.  

3. **Meal Planning**  
   - Personalized meal plans with scheduling and nutritional tracking.  

4. **Shopping List Management**  
   - Generate and manage shopping lists based on meal plans.  

5. **Analytics & Reporting**  
   - Insights on recipe popularity, meal adherence, and grocery spending.

---

## **Folder Structure**
```
MEALPLANNERAPI/
├── Controllers/
│   ├── AuthController.cs
│   ├── MealPlanController.cs
│   └── RecipeController.cs
├── Data/
│   └── ApplicationDbContext.cs
├── DTOs/
│   ├── AuthRequestDto.cs
│   ├── MealPlanDto.cs
│   └── RecipeDto.cs
├── Helpers/
│   └── JwtHelper.cs
├── Models/
│   ├── User.cs
│   ├── Recipe.cs
│   ├── MealPlan.cs
│   ├── Subscription.cs
│   └── Other Model Files...
├── Services/
│   ├── AuthService.cs
│   ├── RecipeService.cs
│   └── MealPlanService.cs
├── Properties/
├── obj/
└── Program.cs
```

---

## **Setup Instructions**
1. **Clone the Repository**
   ```bash
   git clone <repository_url>
   cd MEALPLANNERAPI
   ```

2. **Database Configuration**  
   Update the connection string in `appsettings.json`:
   ```json
   "ConnectionStrings": {
       "DefaultConnection": "Your_Connection_String_Here"
   }
   ```

3. **Install Dependencies**
   ```bash
   dotnet restore
   ```

4. **Run Migrations**
   ```bash
   dotnet ef database update
   ```

5. **Run the Application**
   ```bash
   dotnet run
   ```

---

## **API Endpoints**
| Endpoint              | Method | Description                       |
|-----------------------|--------|-----------------------------------|
| `/api/auth/login`     | POST   | User login with JWT generation    |
| `/api/recipes`        | GET    | Retrieve all recipes              |
| `/api/mealplans`      | POST   | Create a personalized meal plan   |

---

## **Frontend Integration**  
- Connect Angular frontend to the backend using the base URL:  
  `https://localhost:<port>/api/`

---

## **Additional Notes**
- Use Swagger (`/swagger`) for testing APIs.  
- Add CORS policies in `Program.cs` for external integrations.

---

Let me know if you need further details!