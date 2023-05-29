using Microsoft.EntityFrameworkCore;
using BankAPI.Data;
using BankAPI.Data.BankModels;
using BankAPI.Data.DTos;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Services;

public class LoginService
{
    private readonly BankContext _context;

    public LoginService(BankContext context)
    {
        _context = context;
    }

    public async Tasl<Administrator?> GetAdmin(AdminDto admin)
    {
        return await _context.Administrators.
                        SingleOrDefaultAsync(x => x.Email == admin.Email && x.Pwd == admin.Pwd);
    }
}