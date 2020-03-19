using HTKTennisklub.DAL;
using HTKTennisklub.Entities;
using HTKTennisklub.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HTKTennisklub.GUI.UserControls
{
    /// <summary>
    /// Interaction logic for UpdateMemberUserControl.xaml
    /// </summary>
    public partial class UpdateMemberUserControl : UserControl
    {
        public Member Member { get; set; }
        public UpdateMemberUserControl(Member member)
        {
            InitializeComponent();
            Member = member;
            firstName.Text = member.FirstName;
            lastName.Text = member.LastName;
            address.Text = member.Address;
            phoneNumber.Text = member.PhoneNumber;
            email.Text = member.Email;

            Gender[] genders = (Gender[])Enum.GetValues(typeof(Gender)).Cast<Gender>();
            string[] genderDescriptions = new string[genders.Length];
            for (int i = 0; i < genders.Length; i++)
            {
                genderDescriptions[i] = genders[i].GetDescription();
            }
            gender.ItemsSource = genderDescriptions;
            gender.SelectedItem = member.GenderDescription;

            List<Level> levels = new LevelRepository().GetLevels();
            foreach (Level currentLevel in levels)
            {
                level.Items.Add(currentLevel.Name);
            }
            level.SelectedItem = member.Level.Name;
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Member.FirstName = firstName.Text;
            Member.LastName = lastName.Text;
            Member.Address = address.Text;
            Member.PhoneNumber = phoneNumber.Text;
            Member.Email = email.Text;
            Member.Gender = EnumDescription.GetValueFromDescription<Gender>(gender.Text);
            Member.Level = new LevelRepository().GetLevel(level.Text);
            new MemberRepository().UpdateMember(Member);
            MessageBox.Show($"Oplysningerne for {Member.FirstName} {Member.LastName} er opdateret.", "Opdateret");
            Window.GetWindow(this).Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e) => Window.GetWindow(this).Close();
    }
}
